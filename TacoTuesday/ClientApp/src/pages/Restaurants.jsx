import React, { useEffect, useState } from 'react'
import ReactMapGL, { Marker, NavigationControl, Popup } from 'react-map-gl'
import tacoTuesday from '../images/taco-tuesday.svg'
import { SingleRestaurant } from '../components/SingleRestaurant'

export function Restaurants() {
  const [restaurants, setRestaurants] = useState([])
  const [filterText, setFilterText] = useState('')
  const [viewport, setViewport] = useState({
    latitude: 27.77101804911986,
    longitude: -82.66090611749074,
    zoom: 9.8,
  })
  const [selectedMapRestaurant, setSelectedMapRestaurant] = useState(null)

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
        <ReactMapGL
          {...viewport}
          onViewportChange={setViewport}
          style={{ position: 'absolute' }}
          width="100%"
          height="100%"
          mapboxApiAccessToken={process.env.REACT_APP_MAPBOX_TOKEN}
        >
          <div style={{ position: 'absolute', left: 10 }}>
            <NavigationControl />
          </div>

          {selectedMapRestaurant ? (
            <Popup
              latitude={selectedMapRestaurant.latitude}
              longitude={selectedMapRestaurant.longitude}
              closeButton={true}
              closeOnClick={false}
              onClose={() => setSelectedMapRestaurant(null)}
              offsetTop={-5}
            >
              <div>
                <p>{selectedMapRestaurant.name}</p>
                <p>{selectedMapRestaurant.description}</p>
              </div>
            </Popup>
          ) : null}

          {restaurants.map((restaurant) => (
            <Marker
              key={restaurant.id}
              latitude={restaurant.latitude}
              longitude={restaurant.longitude}
            >
              <span
                role="img"
                aria-label="taco"
                onClick={() => setSelectedMapRestaurant(restaurant)}
              >
                🌮
              </span>
            </Marker>
          ))}
        </ReactMapGL>
      </section>

      <ul className="results">
        {restaurants.map((restaurant) => (
          <SingleRestaurant key={restaurant.id} restaurant={restaurant} />
        ))}
      </ul>
    </main>
  )
}
