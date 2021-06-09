import { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'

function getIdFromURL(url) {
  const parts = url.split('/')

  return parts[parts.length - 2]
}

export function Home() {
  const [films, setFilms] = useState([])
  const [people, setPeople] = useState([])

  useEffect(function () {
    async function loadFilms() {
      // Actually load from the API
      const response = await fetch('https://swapi.dev/api/films/')

      // If we got a successful api, then grab the json
      if (response.status === 200) {
        const json = await response.json()

        setFilms(json.results)
      }
    }

    async function loadPeople() {
      // Actually load from the API
      const response = await fetch('https://swapi.dev/api/people/')

      // If we got a successful api, then grab the json
      if (response.status === 200) {
        const json = await response.json()

        setPeople(json.results)
      }
    }

    loadFilms()
    loadPeople()
  }, [])

  return (
    <>
      <p>
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Blanditiis
        sapiente sunt exercitationem nobis? Sint aut tempora velit! Nisi illo
        asperiores culpa deleniti soluta, illum cum molestias, nobis veritatis
        consectetur incidunt?
      </p>
      <div>
        <h3>Featured Films</h3>
        <ul className="film-list">
          {films.map(film => (
            <li key={getIdFromURL(film.url)} className="film">
              <Link to={`/films/${getIdFromURL(film.url)}`}>{film.title}</Link>
            </li>
          ))}
        </ul>
        <h3>Featured Characters</h3>
        <ul className="people-list">
          {people.map(person => (
            <li key={getIdFromURL(person.url)} className="person">
              <Link to={`/people/${getIdFromURL(person.url)}`}>
                {person.name}
              </Link>
            </li>
          ))}
        </ul>
      </div>
    </>
  )
}