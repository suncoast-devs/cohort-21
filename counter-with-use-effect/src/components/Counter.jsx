import React, { useState, useEffect } from 'react'

export function Counter() {
  const [count, setCount] = useState(42)
  const [isHappy, setIsHappy] = useState(true)

  function handleClickButton() {
    setCount(count + 1)
  }

  function handleOtherClickButton() {
    setCount(count * 2)
  }

  function handleClickHappy() {
    // if (isHappy) {
    //   setIsHappy(false)
    // } else {
    //   setIsHappy(true)
    // }
    setIsHappy(!isHappy)
  }

  useEffect(
    // Function to call ONCE *and* when a variable listed below
    // changes
    function () {
      console.log(`This runs once when the component first mounts`)
    },

    // EXCEPT, the list here is empty, so nothing can ever change!
    // thus our code there runs EXACTLY ONCE when the component first mounts
    []
  )

  // Using useEffect
  useEffect(
    // The function to call when a variable changes
    function () {
      console.log(
        `Wow, the count changed and is now ${count} - and I am ${
          isHappy ? 'happy' : 'not happy'
        }`
      )
    },
    // List of values (variables) to monitor
    [count, isHappy]
  )

  return (
    <div>
      <p>
        Count of Clicks: {count}{' '}
        <button onClick={handleClickButton}>Click Me!!!</button>
        <button onClick={handleOtherClickButton}>Or Click Me!!!</button>
      </p>
      <p>Am I happy: {isHappy ? 'Yes' : 'No'}</p>
      <button onClick={handleClickHappy}>Toggle Happiness</button>
    </div>
  )
}

export function SuperAwesomeCounter() {
  return <div>AWESOME!</div>
}
