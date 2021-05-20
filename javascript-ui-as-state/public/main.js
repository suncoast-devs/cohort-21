let counter = 42

function render() {
  const html = `
  <p>${counter}</p>
  <button>Increment</button>
  `

  document.body.innerHTML = html
}

function main() {
  render()

  const button = document.querySelector('button')

  button.addEventListener('click', function (event) {
    counter = counter + 1

    render()
  })
}

document.addEventListener('DOMContentLoaded', main)
