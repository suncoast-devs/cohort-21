import React, { useState, useEffect } from 'react'

export function Counter() {
  const [count, setCount] = useState(0)

  function handleClickButton() {
    setCount(count + 1)
  }

  return (
    <div>
      <p>
        Count: {count} <button onClick={handleClickButton}>Click Me</button>
      </p>
    </div>
  )
}

export function SuperAwesomeCounter() {
  return <div>AWESOME!</div>
}
