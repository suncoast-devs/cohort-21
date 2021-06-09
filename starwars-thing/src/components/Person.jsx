import { useEffect, useState } from 'react'
import { Link, useParams } from 'react-router-dom'
import { getIdFromURL } from './getIdFromURL'

export function Person() {
  const [films, setFilms] = useState([])
  const [loading, setLoading] = useState(true)
  const [person, setPerson] = useState({
    name: '',
    height: '',
    mass: '',
    hair_color: '',
    skin_color: '',
    eye_color: '',
    birth_year: '',
    gender: '',
    homeworld: '',
    films: [],
    species: [],
    vehicles: [],
    starships: [],
    created: '',
    edited: '',
    url: '',
  })
  const params = useParams()

  useEffect(function () {
    async function loadPerson() {
      const response = await fetch(`https://swapi.dev/api/people/${params.id}/`)

      if (response.status === 200) {
        const json = await response.json()
        setPerson(json)

        const filmURLS = json.films
        const promises = filmURLS.map(async filmURL => {
          const response = await fetch(filmURL)

          return response.json()
        })
        const filmData = await Promise.all(promises)
        setFilms(filmData)

        setLoading(false)
      }
    }

    loadPerson()
  }, [])

  // Guard clause, IF we are loading only return a LOADING h2, nothing below
  if (loading) {
    return <h2>Loading...</h2>
  }

  return (
    <>
      <h2>{person.name}</h2>
      <p></p>

      <dl className="person-traits">
        <dt className="trait">Hair Color</dt>
        <dd className="value">{person.hair_color}</dd>
        <dt className="trait">Eye Color</dt>
        <dd className="value">{person.eye_color}</dd>
        <dt className="trait">Birth Year</dt>
        <dd className="value">{person.birth_year}</dd>
      </dl>

      <ul className="film-list">
        {films.map(film => (
          <li key={getIdFromURL(film.url)} className="film">
            <Link to={`/films/${getIdFromURL(film.url)}`}>{film.title}</Link>
          </li>
        ))}
      </ul>
    </>
  )
}
