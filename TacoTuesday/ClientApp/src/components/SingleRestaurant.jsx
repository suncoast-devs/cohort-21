import React from 'react'
import { Link } from 'react-router-dom'
import { Stars } from './Stars'

export function SingleRestaurant({ restaurant }) {
  return (
    <li>
      <h2>
        <Link to={`/restaurants/${restaurant.id}`}>{restaurant.name}</Link>
      </h2>
      <p>
        <Stars restaurant={restaurant} /> ({restaurant.reviews.length})
      </p>
      <address>{restaurant.address}</address>
    </li>
  )
}
