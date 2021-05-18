function main() {
  const colors = ['red', 'green', 'blue']

  function logSomeColor(color, index) {
    console.log(`The color at position ${index} is ${color}`)
  }

  //
  // foreach(var color in colors) {
  //
  // }
  colors.forEach(logSomeColor)
}

document.addEventListener('DOMContentLoaded', main)
