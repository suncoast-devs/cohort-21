// let teamOneName = `Team 1`
// let teamOneScore = 0
// const teamOne = {
//   id: 1,
//   name: 'Team 1',
//   score: 0,
// }

// let teamTwoName = `Team 2`
// let teamTwoScore = 0
// const teamTwo = {
//   id: 2,
//   name: 'Team 2',
//   score: 0,
// }

const teams = [
  {
    id: 1,
    name: 'Team 1',
    score: 0,
  },
  {
    id: 2,
    name: 'Team 2',
    score: 0,
  },
  {
    id: 3,
    name: 'Team 3',
    score: 0,
  },
  {
    id: 4,
    name: 'Team 4',
    score: 0,
  },
]

function renderTeam(whichTeamToRender) {
  const html = `
<section class="team${whichTeamToRender.id}">
  <h2>${whichTeamToRender.name}</h2>
  <h3>${whichTeamToRender.score}</h3>
  <fieldset>
    <input type="text" placeholder="Name" value="${whichTeamToRender.name}" />
  </fieldset>

  <fieldset>
    <i class="add fas fa-2x fa-plus-circle"></i>
    <i class="subtract fas fa-2x fa-minus-circle"></i>
  </fieldset>
</section>
  `

  return html
}

function setupListeners(team) {
  document
    .querySelector(`.team${team.id} .add`)
    .addEventListener('click', function (event) {
      team.score++
      render()
    })
  document
    .querySelector(`.team${team.id} .subtract`)
    .addEventListener('click', function (event) {
      team.score--
      render()
    })
  document
    .querySelector(`.team${team.id} input`)
    .addEventListener('input', function (event) {
      team.name = event.target.value
      render()
    })
}

function render() {
  const html = `
<header>
  <h1>My Score Board</h1>
</header>
<main>
  ${teams
    .map(function (team) {
      return renderTeam(team)
    })
    .join('')}
</main>
  `

  document.body.innerHTML = html

  // setupListeners(teamOne)
  // setupListeners(teamTwo)
  teams.forEach(function (team) {
    setupListeners(team)
  })
}

function main() {
  render()
}

document.addEventListener('DOMContentLoaded', main)
