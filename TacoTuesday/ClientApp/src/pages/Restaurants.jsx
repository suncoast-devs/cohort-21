import React, { useEffect, useState } from 'react'
import tacoTuesday from '../images/taco-tuesday.svg'
import map from '../images/map.png'
import { Link } from 'react-router-dom'

export function Restaurants() {
  const [restaurants, setRestaurants] = useState([])
  const [filterText, setFilterText] = useState('')

  useEffect(
    function () {
      async function loadRestaurants() {
        const url =
          filterText.length === 0
            ? '/api/Restaurants'
            : `/api/Restaurants?filter=${filterText}`

        const response = await fetch(url)

        if (response.ok) {
          const json = await response.json()

          setRestaurants(json)
        }
      }

      loadRestaurants()
    },
    [filterText]
  )

  return (
    <main className="home">
      <h1>
        <img src={tacoTuesday} alt="Taco Tuesday" />
      </h1>
      <form className="search">
        <input
          type="text"
          placeholder="Search..."
          value={filterText}
          onChange={function (event) {
            setFilterText(event.target.value)
          }}
        />
      </form>

      <section className="map">
        <img alt="Example Map" src={map} />
      </section>

      <ul className="results">
        {restaurants.map((restaurant) => (
          <li key={restaurant.id}>
            <h2>
              <Link to={`/restaurants/${restaurant.id}`}>
                {restaurant.name}
              </Link>
            </h2>
            <p>
              <span
                className="stars"
                style={{ '--rating': 4.7 }}
                aria-label="Star rating of this location is 4.7 out of 5."
              ></span>
              ({restaurant.reviews.length})
            </p>
            <address>{restaurant.address}</address>
          </li>
        ))}
      </ul>
    </main>
  )
}
