import React, { useEffect } from 'react';
import Header from './Header';
import ArticleDashboard from '../../features/articles/dashboard/ArticleDashboard';
import { Container } from 'semantic-ui-react';
import { observer } from 'mobx-react-lite';
import { Route, Switch, useLocation } from 'react-router-dom';
import Home from '../../features/home/Home';
import ArticleForm from '../../features/articles/form/ArticleForm';
import { ThemeProvider, createTheme } from '@mui/material/styles';
import ArticleDetails from '../../features/articles/details/ArticleDetails';
import { ToastContainer } from 'react-toastify';
import NotFound from '../../features/errors/NotFound';
import { useStore } from '../stores/store';
import LoadingComponent from './LoadingComponent';
import ModalContainer from '../common/modals/ModalContainer';
import ProfilePage from '../../features/profiles/ProfilePage';
import RegisterSuccess from '../../features/users/RegisterSuccess';
import ConfirmEmail from '../../features/users/ConfirmEmail';
import PrivateRoute from './PrivateRoute';
import CSharp from '../../features/coding/csharp/model/CSharp';
import Controller from '../../features/coding/csharp/controller/Controller';
import Angular from '../../features/coding/angular/Angular';
import Footer from './Footer';
import ReactFramework from '../../features/coding/react/React';
import Info from '../../features/coding/javascript/Info';
import Details from '../../features/coding/csharp/cqrs/Details';

const darkTheme = createTheme({
  palette: {
    mode: 'dark',
  },
});

function App() {
  const location = useLocation();
  const { commonStore, userStore } = useStore();

  useEffect(() => {
    if (commonStore.token) {
      userStore.getUser().finally(() => commonStore.setAppLoaded());
    } else {
      commonStore.setAppLoaded();
    }
  }, [commonStore, userStore])

  if (!commonStore.appLoaded) return <LoadingComponent content='Loading app...' />

  return (
    <div className="App">
      <ThemeProvider theme={darkTheme}>
        <ToastContainer position='bottom-right' hideProgressBar />   
        <ModalContainer />
        <Header />
        <Route exact path='/' component={Home} />  
        <Route path='/csharp' component={CSharp} />
        <Route path='/controller' component={Controller} />
        <Route path='/cqrs' component={Details} />
        <Route path='/javascript' component={Info} />
        <Route path='/angular' component={Angular} />
        <Route path='/react' component={ReactFramework} />
        <Route exact path='/articles' component={ArticleDashboard} />
        <Route
          path={'/(.+)'}
          render={() => (
            <>
              <Container style={{ width: '100vw' }}>
                <Switch>
                  <PrivateRoute path='/articles/:id' component={ArticleDetails} />
                  <PrivateRoute key={location.key} path={['/createArticle', '/manage/:id']} component={ArticleForm} />
                  <PrivateRoute path='/profiles/:username' component={ProfilePage} />
                  <Route path='/account/registerSuccess' component={RegisterSuccess} />
                  <Route path='/account/verifyEmail' component={ConfirmEmail} />
                  {/* <Route component={NotFound} /> */}
                </Switch>
              </Container> 
          </>
        )}
      />   
      </ThemeProvider>    
    </div>
  );
}

export default observer(App);
