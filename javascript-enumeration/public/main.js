function main() {
  const colors = ['red', 'green', 'blue']

  // function logSomeColor(color, index) {
  //   console.log(`The color at position ${index} is ${color}`)
  // }

  //
  // foreach(var color in colors) {
  //
  // }

  // anonymous INLINE function
  //
  // anonymous since it has no function name
  // INLINE because we declare it and use it in one step
  colors.forEach(function (color, index) {
    console.log(`The color at position ${index} is ${color}`)
  })

  // const lengths = []

  // colors.forEach(function (color) {
  //   const lengthOfColor = color.length

  //   lengths.push(lengthOfColor)
  // })

  //
  // var lengths = colors.Select(color => color.Length);
  //
  const lengths = colors.map(function (color) {
    const length = color.length

    return length
  })

  const uppercased = colors.map(function (color) {
    const uppercase = color.toUpperCase()

    return uppercase
  })

  console.log(lengths)
  console.log(uppercased)
}

document.addEventListener('DOMContentLoaded', main)
