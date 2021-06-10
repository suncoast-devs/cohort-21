import axios from 'axios'
import { useEffect, useState } from 'react'
import { useQuery } from 'react-query'
import { Link } from 'react-router-dom'
import { getIdFromURL } from './getIdFromURL'

export function Home() {
  const {
    isLoading: filmsAreLoading,
    error: filmError,
    data: filmData,
  } = useQuery('filmData', () => axios.get('https://swapi.dev/api/films/'))

  const {
    isLoading: peopleAreLoading,
    error: peopleError,
    data: peopleData,
  } = useQuery('peopleData', () => axios.get('https://swapi.dev/api/people/'))

  if (filmsAreLoading || peopleAreLoading) {
    return <p>Loading...</p>
  }

  if (peopleError || filmError) {
    return (
      <ul>
        <li>{peopleError.message}</li>
        <li>{filmError.message}</li>
      </ul>
    )
  }

  /* peopleData is a react-query thing */
  /* data is an axios thing */
  /* results is the name of the key in the API data */
  /* Yuck, can we just rename this people?!? */
  const people = peopleData.data.results
  const films = filmData.data.results

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
