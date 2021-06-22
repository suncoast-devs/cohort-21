import React from 'react'

export function Stars({ restaurant }) {
  const totalStars = restaurant.reviews.reduce(
    (starRatingSum, review) => starRatingSum + review.stars,
    0
  )

  const averageStars =
    restaurant.reviews.length === 0 ? 0 : totalStars / restaurant.reviews.length
  const averageStarsToOneDecimalPlace = averageStars.toFixed(1)

  return (
    <span
      className="stars"
      style={{ '--rating': averageStarsToOneDecimalPlace }}
      aria-label={`Star rating of this location is ${averageStarsToOneDecimalPlace} out of 5.`}
    ></span>
  )
}
