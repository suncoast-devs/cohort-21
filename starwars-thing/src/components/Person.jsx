import { Link } from 'react-router-dom'

export function Person() {
  return (
    <>
      <h2>Hans Solo</h2>
      <p>
        Lorem ipsum dolor, sit amet consectetur adipisicing elit. Mollitia ea
        officiis odit, eius magni ratione blanditiis ipsam iste accusantium
        asperiores quae repellat quidem at laborum reprehenderit eligendi saepe
        possimus veniam.
      </p>

      <dl className="person-traits">
        <dt className="trait">Hair Color</dt>
        <dd className="value">Blonde</dd>
        <dt className="trait">Eye Color</dt>
        <dd className="value">Blue</dd>
        <dd className="value">Green</dd>
        <dt className="trait">Birth Year</dt>
        <dd className="value">19 BBY</dd>
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
