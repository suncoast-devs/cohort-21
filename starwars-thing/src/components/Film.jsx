import { useEffect, useState } from 'react'
import { Link, useParams } from 'react-router-dom'
import { getIdFromURL } from './getIdFromURL'

export function Film() {
  const [film, setFilm] = useState({
    title: '',
    episode_id: 0,
    opening_crawl: '',
    director: '',
    producer: '',
    release_date: '',
    characters: [],
    planets: [],
    starships: [],
    vehicles: [],
    species: [],
    created: '',
    edited: '',
    url: '',
  })
  const [characters, setCharacters] = useState([])
  const params = useParams()

  useEffect(function () {
    // Load data here
    async function fetchFilm() {
      const response = await fetch(`https://swapi.dev/api/films/${params.id}/`)

      if (response.status === 200) {
        const json = await response.json()
        setFilm(json)

        const characterURLs = json.characters
        const promises = characterURLs.map(async characterURL => {
          const response = await fetch(characterURL)

          return response.json()
        })
        const characterData = await Promise.all(promises)

        setCharacters(characterData)
      }
    }

    fetchFilm()
  }, [])

  return (
    <>
      <h2>{film.title}</h2>

      <p className="preamble">Long long ago, in a galaxy far, far away.</p>

      <div className="crawl">{film.opening_crawl}</div>

      <ul className="people-list">
        {characters.map(character => (
          <li key={getIdFromURL(character.url)}>
            <Link to={`/people/${getIdFromURL(character.url)}`}>
              {character.name}
            </Link>
          </li>
        ))}
      </ul>
    </>
  )
}
