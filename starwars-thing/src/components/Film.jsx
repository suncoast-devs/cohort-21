import { Link } from 'react-router-dom'

export function Film() {
  return (
    <>
      <h2>Episode IV: A New Hope</h2>

      <p className="preamble">Long long ago, in a galaxy far, far away.</p>

      <div className="crawl">
        It is a period of civil war. Rebel spaceships, striking from a hidden
        base, have won their first victory against the evil Galactic Empire.
        During the battle, Rebel spies managed to steal secret\r plans to the
        Empire's ultimate weapon, the DEATH STAR, an armored space station with
        enough power to destroy an entire planet. Pursued by the Empire's
        sinister agents, Princess Leia races home aboard her starship, custodian
        of the stolen plans that can save her people and restore freedom to the
        galaxy....
      </div>

      <ul className="people-list">
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
    </>
  )
}
