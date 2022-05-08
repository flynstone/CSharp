import { Card, CardContent, CardHeader } from '@mui/material';
import React from 'react';
import { Grid } from 'semantic-ui-react';

const Teal = {
  color: 'teal',
}

const Orange = {
  color: 'orange'
}

export default function ReactFramework() {
  return(
    <Grid style={{ padding: '2rem', justifyContent: 'center' }}>
      <Grid.Column width="12">
        <Card>
          <CardHeader /><h2>Javascript / Typescript <b style={Teal}> React</b></h2>
          <CardContent>
            <div className='Container'>
              <p>React is a popular <b style={Teal}>Font-End</b> framework created by <b style={Teal}>Facebook</b></p>
              <br />
              <p>The back-end for this section is the <b style={Teal}>Clean Architechture Pattern</b>.</p>
            </div>

            <div className="Text">
              <p>I first start by creating a new project with the command <b style={Orange}>npx create-react-app app-name --template typescript</b>.</p>
              <p>I then open the new project in <b style={Teal}>Visual Studio Code</b>.</p>
              <p>In the source folder, I add a folder called <b style={Teal}>app</b>. Inside that app folder, I create another new folder called layout. I then delete the logo.svg file drag and drop the App.tsx, App.test.tsx, index.css into the layout folder. I then rename the index.css to styles.css.</p>
              <p>Heres a list a of a few packages I will be installing.</p>
              <ul>
                <li><b style={Teal}>axios</b></li>
                <li><b style={Teal}>react-router-dom@5.2.0</b></li>
                <li><b style={Teal}>semantic-ui-css</b></li>
                <li><b style={Teal}>semantic-ui-react</b></li>
                <li><b style={Teal}>@mui/material</b></li>
                
              </ul>

              <br/>
              <p>Inside the layout folder I will create a new file called AppHeader.tsx</p>
            </div>
          </CardContent>
        </Card>
      </Grid.Column>
    </Grid>
  )
}