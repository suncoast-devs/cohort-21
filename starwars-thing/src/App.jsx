import { Route, Switch } from 'react-router-dom'
import { Film, Home, Layout, Person } from './components'

export function App() {
  return (
    <Layout>
      <Switch>
        <Route exact path="/">
          <Home />
        </Route>
        <Route exact path="/people/:id">
          <Person />
        </Route>
        {/*                /films/4 */}
        <Route exact path="/films/:id">
          <Film />
        </Route>
        <Route path="*">Not Found</Route>
      </Switch>
    </Layout>
  )
}
