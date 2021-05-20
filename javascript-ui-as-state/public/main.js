// let teamOneName = `Team 1`
// let teamOneScore = 0
const teamOne = {
  name: 'Team 1',
  score: 0,
}

// let teamTwoName = `Team 2`
// let teamTwoScore = 0
const teamTwo = {
  name: 'Team 2',
  score: 0,
}

function render() {
  const html = `
<header>
  <h1>My Score Board</h1>
</header>
<main>
  <section class="team1">
    <h2>${teamOne.name}</h2>
    <h3>${teamOne.score}</h3>
    <fieldset>
      <input type="text" placeholder="Name" value="${teamOne.name}" />
    </fieldset>

    <fieldset>
      <i class="add fas fa-2x fa-plus-circle"></i>
      <i class="subtract fas fa-2x fa-minus-circle"></i>
    </fieldset>
  </section>

  <section class="team2">
    <h2>${teamTwo.name}</h2>
    <h3>${teamTwo.score}</h3>
    <fieldset>
      <input type="text" placeholder="Name" value="${teamTwo.name}" />
    </fieldset>

    <fieldset>
      <i class="add fas fa-2x fa-plus-circle"></i>
      <i class="subtract fas fa-2x fa-minus-circle"></i>
    </fieldset>
  </section>
</main>
  `

  document.body.innerHTML = html

  document
    .querySelector('.team1 .add')
    .addEventListener('click', function (event) {
      teamOne.score++
      render()
    })
  document
    .querySelector('.team1 .subtract')
    .addEventListener('click', function (event) {
      teamOne.score--
      render()
    })
  document
    .querySelector('.team1 input')
    .addEventListener('input', function (event) {
      teamOne.name = event.target.value
      render()
    })

  document
    .querySelector('.team2 .add')
    .addEventListener('click', function (event) {
      teamTwo.score++
      render()
    })
  document
    .querySelector('.team2 .subtract')
    .addEventListener('click', function (event) {
      teamTwo.score--
      render()
    })
  document
    .querySelector('.team2 input')
    .addEventListener('input', function (event) {
      teamTwo.name = event.target.value
      render()
    })
}

function main() {
  render()
}

document.addEventListener('DOMContentLoaded', main)
