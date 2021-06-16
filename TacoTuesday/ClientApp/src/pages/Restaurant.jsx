import React, { useEffect, useState } from 'react'
import { Link, useParams } from 'react-router-dom'
import format from 'date-fns/format'

import avatar from '../images/avatar.png'

const dateFormat = `EEEE, MMMM do, yyyy 'at' h:mm aaa`

export function Restaurant() {
  const params = useParams()
  const id = params.id

  const [restaurant, setRestaurant] = useState({
    name: '',
    description: '',
    address: '',
    telephone: '',
    reviews: [],
  })

  const [newReview, setNewReview] = useState({
    body: '',
    summary: '',
    stars: 3,
    restaurantId: id,
  })

  async function fetchRestaurant() {
    const response = await fetch(`/api/Restaurants/${id}`)

    if (response.ok) {
      const apiData = await response.json()

      setRestaurant(apiData)
    }
  }

  useEffect(() => {
    fetchRestaurant()
  }, [id])

  function handleNewReviewTextFieldChange(event) {
    const name = event.target.name
    const value = event.target.value

    setNewReview({ ...newReview, [name]: value })
  }

  function handleStarRadioButton(newStars) {
    setNewReview({ ...newReview, stars: newStars })
  }

  async function handleNewReviewSubmit(event) {
    event.preventDefault()

    const response = await fetch(`/api/Reviews`, {
      method: 'POST',
      headers: { 'content-type': 'application/json' },
      body: JSON.stringify(newReview),
    })

    if (response.ok) {
      // Clear the form
      setNewReview({
        ...newReview,
        body: '',
        summary: '',
        stars: 0,
      })

      // Reload the restaurant (including the reviews!)
      fetchRestaurant()
    }
  }

  return (
    <main className="page">
      <nav>
        <Link to="/">
          <i className="fa fa-home"></i>
        </Link>
        <h2>{restaurant.name}</h2>
      </nav>
      <p>
        <span
          className="stars"
          style={{ '--rating': 4.7 }}
          aria-label="Star rating of this location is 4.7 out of 5."
        ></span>
        ({restaurant.reviews.length})
      </p>
      <address>{restaurant.address}</address>
      <hr />

      {/* Conditionally show some content IF the length of the reviews array is more than 0
            e.g. there are some reviews to show */}
      {restaurant.reviews.length > 0 ? (
        <h3>Reviews for {restaurant.name}</h3>
      ) : null}

      <ul className="reviews">
        {restaurant.reviews.map((review) => (
          <li>
            <div className="author">
              Gavin said: <em>{review.summary}</em>
            </div>
            <div className="body">
              <p>{review.body}</p>
            </div>
            <div className="meta">
              <span
                className="stars"
                style={{ '--rating': review.stars }}
                aria-label={`Star rating of this location is ${review.stars} out of 5.`}
              ></span>
              <time>{format(new Date(review.createdAt), dateFormat)}</time>
            </div>
          </li>
        ))}
      </ul>
      <h3>Enter your own review</h3>
      <form onSubmit={handleNewReviewSubmit}>
        <p className="form-input">
          <label htmlFor="summary">Summary</label>
          <input
            type="text"
            name="summary"
            value={newReview.summary}
            onChange={handleNewReviewTextFieldChange}
          />
          <span className="note">
            Enter a brief summary of your review. Example:{' '}
            <strong>Great food, good prices.</strong>
          </span>
        </p>
        <p className="form-input">
          <label htmlFor="body">Review</label>
          <textarea
            name="body"
            value={newReview.body}
            onChange={handleNewReviewTextFieldChange}
          ></textarea>
        </p>
        <div className="rating">
          <input
            id="star-rating-1"
            type="radio"
            name="stars"
            value="1"
            checked={newReview.stars === 1}
            onChange={() => handleStarRadioButton(1)}
          />
          <label htmlFor="star-rating-1">1 star</label>
          <input
            id="star-rating-2"
            type="radio"
            name="stars"
            value="2"
            checked={newReview.stars === 2}
            onChange={() => handleStarRadioButton(2)}
          />
          <label htmlFor="star-rating-2">2 stars</label>
          <input
            id="star-rating-3"
            type="radio"
            name="stars"
            value="3"
            checked={newReview.stars === 3}
            onChange={() => handleStarRadioButton(3)}
          />
          <label htmlFor="star-rating-3">3 stars</label>
          <input
            id="star-rating-4"
            type="radio"
            name="stars"
            value="4"
            checked={newReview.stars === 4}
            onChange={() => handleStarRadioButton(4)}
          />
          <label htmlFor="star-rating-4">4 stars</label>
          <input
            id="star-rating-5"
            type="radio"
            name="stars"
            value="5"
            checked={newReview.stars === 5}
            onChange={() => handleStarRadioButton(5)}
          />
          <label htmlFor="star-rating-5">5 stars</label>

          <div className="star-rating">
            <label
              htmlFor="star-rating-1"
              aria-label="1 star"
              title="1 star"
            ></label>
            <label
              htmlFor="star-rating-2"
              aria-label="2 stars"
              title="2 stars"
            ></label>
            <label
              htmlFor="star-rating-3"
              aria-label="3 stars"
              title="3 stars"
            ></label>
            <label
              htmlFor="star-rating-4"
              aria-label="4 stars"
              title="4 stars"
            ></label>
            <label
              htmlFor="star-rating-5"
              aria-label="5 stars"
              title="5 stars"
            ></label>
          </div>
        </div>
        <p>
          <input type="submit" value="Submit" />
        </p>
      </form>
    </main>
  )
}
