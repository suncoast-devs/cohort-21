import React, { useState, useEffect } from 'react'

export function Counter() {
  const [count, setCount] = useState(0)

  function handleClickButton() {
    setCount(count + 1)
  }

  function handleOtherClickButton() {
    setCount(count * 2)
  }

  // Using useEffect
  useEffect(
    // The function to call when a variable changes
    function () {
      console.log(`Wow, the count changed and is now ${count}`)
    },
    // List of values (variables) to monitor
    [count]
  )

  return (
    <div>
      <p>
        Count of Clicks: {count}{' '}
        <button onClick={handleClickButton}>Click Me!!!</button>
        <button onClick={handleOtherClickButton}>Or Click Me!!!</button>
      </p>
    </div>
  )
}

export function SuperAwesomeCounter() {
  return <div>AWESOME!</div>
}
