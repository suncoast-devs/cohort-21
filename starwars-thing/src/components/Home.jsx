import { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'

export function Home() {
  const [films, setFilms] = useState([])

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

    loadFilms()
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
            <li key={film.url} className="film">
              <Link to="/films/1">{film.title}</Link>
            </li>
          ))}
        </ul>
        <h3>Featured Characters</h3>
        <ul className="people-list">
          <li className="person">
            <Link to="/people/1">Hans Solo</Link>
          </li>
          <li className="person">
            <Link to="/people/1">Yoda</Link>
          </li>
          <li className="person">
            <Link to="/people/1">Boba Fett</Link>
          </li>
          <li className="person">
            <Link to="/people/1">Hans Solo</Link>
          </li>
          <li className="person">
            <Link to="/people/1">Yoda</Link>
          </li>
          <li className="person">
            <Link to="/people/1">Boba Fett</Link>
          </li>
          <li className="person">
            <Link to="/people/1">Hans Solo</Link>
          </li>
          <li className="person">
            <Link to="/people/1">Yoda</Link>
          </li>
          <li className="person">
            <Link to="/people/1">Boba Fett</Link>
          </li>
          <li className="person">
            <Link to="/people/1">Hans Solo</Link>
          </li>
          <li className="person">
            <Link to="/people/1">Yoda</Link>
          </li>
          <li className="person">
            <Link to="/people/1">Boba Fett</Link>
          </li>
        </ul>
      </div>
    </>
  )
}
