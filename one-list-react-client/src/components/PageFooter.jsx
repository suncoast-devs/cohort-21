import React from 'react'
import logo from '../images/sdg-logo.png'

export function PageFooter() {
  return (
    <footer>
      <p>
        <img src={logo} height="42" alt="logo" />
      </p>
      <p>&copy; 2020 Suncoast Developers Guild</p>
    </footer>
  )
}
