import React, { useState } from 'react'
import { Link, useHistory } from 'react-router-dom'
import { useDropzone } from 'react-dropzone'
import { authHeader } from '../auth'

export function NewRestaurant() {
  const [newRestaurant, setNewRestaurant] = useState(
    // Shape of what we are SENDING to the API
    {
      name: '',
      description: '',
      address: '',
      telephone: '',
      photoURL: '',
    }
  )
  const [errorMessage, setErrorMessage] = useState('')
  const [isUploading, setIsUploading] = useState(false)
  const history = useHistory()

  const { getRootProps, getInputProps, isDragActive } = useDropzone({
    onDrop: onDropFile,
  })

  function handleStringFieldChange(event) {
    const value = event.target.value
    const fieldName = event.target.name

    setNewRestaurant({ ...newRestaurant, [fieldName]: value })
  }

  async function handleFormSubmit(event) {
    event.preventDefault()

    const response = await fetch('/api/Restaurants', {
      method: 'POST',
      // Send that we are sending JSON *AND* send along our authentication headers (our token)
      headers: { 'content-type': 'application/json', ...authHeader() },
      body: JSON.stringify(newRestaurant),
    })

    if (response.status === 401) {
      setErrorMessage('Not Authorized')
    } else {
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
  }

  // Takes an array of accepted files (dropped files)
  async function onDropFile(acceptedFiles) {
    // Do something with the files
    const fileToUpload = acceptedFiles[0]

    setIsUploading(true)

    // Create a formData object so we can send this
    // to the API that is expecting som form data.
    const formData = new FormData()

    // Append a field that is the form upload itself
    formData.append('file', fileToUpload)

    try {
      // Use fetch to send an authorization header and
      // a body containing the form data with the file
      const response = await fetch('/api/Uploads', {
        method: 'POST',
        headers: {
          ...authHeader(),
        },
        body: formData,
      })

      // If we receive a 200 OK response, set the
      // URL of the photo in our state so that it is
      // sent along when creating the restaurant,
      // otherwise show an error
      if (response.ok) {
        const apiResponse = await response.json()

        const url = apiResponse.url

        setNewRestaurant({ ...newRestaurant, photoURL: url })
      } else {
        setErrorMessage('Unable to upload image')
      }
    } catch {
      // Catch any network errors and show the user we could not process their upload
      setErrorMessage('Unable to upload image')
    }

    setIsUploading(false)
  }

  let dropZoneMessage = 'Drag a picture of the restaurant here to upload!'

  if (isUploading) {
    dropZoneMessage = 'Uploading...'
  }

  if (isDragActive) {
    dropZoneMessage = 'Drop the files here ...'
  }

  return (
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

        {newRestaurant.photoURL ? (
          <p>
            <img alt="Restaurant" width={200} src={newRestaurant.photoURL} />
          </p>
        ) : null}

        <div className="file-drop-zone">
          <div {...getRootProps()}>
            <input {...getInputProps()} />
            {dropZoneMessage}
          </div>
        </div>

        <p>
          <input type="submit" value="Submit" />
        </p>
      </form>
    </main>
  )
}
