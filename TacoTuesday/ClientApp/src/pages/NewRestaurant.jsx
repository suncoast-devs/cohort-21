import React, { useState } from 'react'
import { Link, useHistory } from 'react-router-dom'
import avatar from '../images/avatar.png'

export function NewRestaurant() {
  const [newRestaurant, setNewRestaurant] = useState(
    // Shape of what we are SENDING to the API
    {
      name: '',
      description: '',
      address: '',
      telephone: '',
    }
  )
  const [errorMessage, setErrorMessage] = useState('')
  const history = useHistory()

  function handleStringFieldChange(event) {
    const value = event.target.value
    const fieldName = event.target.name

    setNewRestaurant({ ...newRestaurant, [fieldName]: value })
  }

  async function handleFormSubmit(event) {
    event.preventDefault()

    const response = await fetch('/api/Restaurants', {
      method: 'POST',
      headers: { 'content-type': 'application/json' },
      body: JSON.stringify(newRestaurant),
    })

    if (response.ok) {
      history.push('/')
    } else {
      // Show errors!
      const json = await response.json()

      const errors = json.errors
      const messages = Object.values(errors)
      const errorMessageSentence = messages.join(' ')
      setErrorMessage(errorMessageSentence)
    }
  }

  return (
    <>
      <header>
        <ul>
          <li>
            <nav>
              <Link to="/new">
                <i className="fa fa-plus"></i> Restaurant
              </Link>
              <p>Welcome back, Steve!</p>
            </nav>
          </li>
          <li className="avatar">
            <img src={avatar} alt="Steve's Avatar" height="64" width="64" />
          </li>
        </ul>
      </header>
      <main className="page">
        <nav>
          <Link to="/">
            <i className="fa fa-home"></i>
          </Link>
          <h2>Add a Restaurant</h2>
        </nav>
        <form onSubmit={handleFormSubmit}>
          {errorMessage ? <p>{errorMessage}</p> : null}
          <p className="form-input">
            <label htmlFor="name">Name</label>
            <input
              type="text"
              name="name"
              value={newRestaurant.name}
              onChange={handleStringFieldChange}
            />
          </p>
          <p className="form-input">
            <label htmlFor="description">Description</label>
            <textarea
              name="description"
              value={newRestaurant.description}
              onChange={handleStringFieldChange}
            ></textarea>
            <span className="note">
              Enter a brief description of the restaurant.
            </span>
          </p>
          <p className="form-input">
            <label htmlFor="name">Address</label>
            <textarea
              name="address"
              value={newRestaurant.address}
              onChange={handleStringFieldChange}
            ></textarea>
          </p>
          <p className="form-input">
            <label htmlFor="name">Telephone</label>
            <input
              type="tel"
              name="telephone"
              value={newRestaurant.telephone}
              onChange={handleStringFieldChange}
            />
          </p>
          <p className="form-input">
            <label htmlFor="picture">Picture</label>
            <input type="file" name="picture" />
          </p>
          <p>
            <input type="submit" value="Submit" />
          </p>
        </form>
      </main>
      <footer>
        <p>
          Built with <i className="fa fa-heart"></i> in St Petersburg, Florida.
        </p>
      </footer>
    </>
  )
}
