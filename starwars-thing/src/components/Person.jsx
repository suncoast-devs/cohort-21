import { useEffect, useState } from 'react'
import { Link, useParams } from 'react-router-dom'

export function Person() {
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
        <li className="film">
          <Link to="/films/1">Episode IV: A New Hope</Link>
        </li>
        <li className="film">
          <Link to="/films/1">Episode VII: The Force Awakens</Link>
        </li>
        <li className="film">
          <Link to="/films/1">Episode V: Empire Strikes Back</Link>
        </li>
      </ul>
    </>
  )
}
