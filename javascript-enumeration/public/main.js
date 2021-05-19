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
  const lengths = colors.map(color => color.length)

  // These two are exactly the same
  //
  // function (color) {
  //   return color.toUpperCase()
  // }
  //
  // color => color.toUpperCase()

  const uppercased = colors.map(color => color.toUpperCase())

  console.log(lengths)
  console.log(uppercased)

  // C#:   var longColors = colors.Where(color => color.Length > 4)
  // const longColors = colors.filter(function (color) {
  //   return color.length > 4
  // })
  const longColors = colors.filter(color => color.length > 4)

  console.log(longColors)
}

document.addEventListener('DOMContentLoaded', main)
