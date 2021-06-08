import { Link } from 'react-router-dom'

export function Home() {
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
