import { useEffect, useState } from 'react'
import { useQuery } from 'react-query'
import { Link } from 'react-router-dom'
import { getIdFromURL } from './getIdFromURL'

export function Home() {
  const {
    isLoading: filmsAreLoading,
    error: filmError,
    data: filmData,
  } = useQuery('filmData', () =>
    fetch('https://swapi.dev/api/films/').then(res => res.json())
  )

  const {
    isLoading: peopleAreLoading,
    error: peopleError,
    data: peopleData,
  } = useQuery('peopleData', () =>
    fetch('https://swapi.dev/api/people/').then(res => res.json())
  )

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
          {filmData.results.map(film => (
            <li key={getIdFromURL(film.url)} className="film">
              <Link to={`/films/${getIdFromURL(film.url)}`}>{film.title}</Link>
            </li>
          ))}
        </ul>
        <h3>Featured Characters</h3>
        <ul className="people-list">
          {peopleData.results.map(person => (
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
