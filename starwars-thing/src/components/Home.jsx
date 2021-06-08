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
        <ul>
          <li>
            <Link to="/films/1">Episode IV: A New Hope</Link>
          </li>
          <li>
            <Link to="/films/1">Episode VII: The Force Awakens</Link>
          </li>
          <li>
            <Link to="/films/1">Episode V: Empire Strikes Back</Link>
          </li>
        </ul>
        <ul>
          <li>
            <Link to="/people/1">Hans Solo</Link>
          </li>
          <li>
            <Link to="/people/1">Yoda</Link>
          </li>
          <li>
            <Link to="/people/1">Boba Fett</Link>
          </li>
        </ul>
      </div>
    </>
  )
}
