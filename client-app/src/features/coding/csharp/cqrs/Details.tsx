import { Card, CardContent, CardHeader } from '@mui/material';
import React from 'react';
import { Grid } from 'semantic-ui-react';
import clean from '../../../../assets/img/CleanArchitecture.jpg';
import cqrs from '../../../../assets/img/cqrs.png';
import AppDbContext from './code/AppDbContext';
import ArticleClass from './code/ArticleClass';
import ArticleL from './code/ArticleL';

const Teal = {
  color: 'teal',
  paddingLeft: '10px' 
}

const Orange = {
  color: 'orange'
}

const Violet = {
  color: 'violet'
}

export default function Details() {
  return(
    <Grid style={{ padding: '2rem', justifyContent: 'center' }}>
      <Grid.Column width="10">
        <Card>
          <CardHeader /><h2>C# (Asp.Net Core Web Api) - <b style={Teal}>CQRS and Clean Architecture</b></h2>
          <CardContent>
            <div className='Text'>
              <p>What does CQRS stand for?</p>
              <br />
              <p><b>Command Query Responsibility Segregation</b>. This type of pattern is built in a way use a different model to read information and another to update information.</p>
              <br />
              <p>The Clean Architecture structure is as follows, I will not got into details but I will seperate project with 4 different layers which will be grouped by concern.</p>
            </div>
            <div className='Image'>
              <img src={cqrs} alt='cqrs' />
              <img src={clean}  alt='alt' />
            </div>

            <div className='Text'>
              <h3>References</h3>
              <a href='https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html'>https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html</a>
              <a href='https://martinfowler.com/bliki/CQRS.html'>https://martinfowler.com/bliki/CQRS.html</a>
            </div>


            <div className='Text'>
              <p>First step will be to create a new project, I will call the<b style={Teal}>Solution</b> Web and the<b style={Teal}>project</b> Web.Api (this will be the green layer of the clean architecture "named Interface Adapters").</p>
              <p>Next step will be to create a new project that will be a<b style={Teal}>c# class library</b> called Web.Application (this will be the red layer "named Application Business Rules").</p>
              <p>We then again create a new project<b style={Teal}>c# class library</b> called Web.Entities (this will be the yellow layer "also known as domain").</p>
              <p>One more new project to create (for now) again a<b style={Teal}>c# class library</b> called Web.Database (this will be the blue layer).</p>
            </div>
            <div className='Text'>
              <p>Next step will be to add references between the projects.</p>
              <p><b style={Orange}>Web.Api</b> will reference the Web.Application and the Web.Entities</p>
              <p><b style={Orange}>Web.Application</b> will reference the Web.Database and the Web.Entities</p>
              <p><b style={Orange}>Web.Database</b> will reference the Web.Entities</p>
            </div>
              
            <div className='Text'>
              <p>First will be to create a new folder inside <b style={Orange}>Web.Entities</b> called <b style={Violet}>Models</b>. Inside the Models folder we create a new c# class called Article.</p>
              <p>We must also install the nuget package <b style={Violet}>Microsoft.EntityFrameworkCore</b> in our <b style={Orange}>Web.Entities</b></p>
            </div>

            <ArticleClass />

            <div className='Text'>
              <p>Now we go inside the <b style={Orange}>Web.Database</b> and create a new class called <b style={Violet}>AppDbContext</b></p>
            </div>

            <AppDbContext />

            <div className='Text'>
              <p>Next we will go inside the <b style={Orange}>Web.Application</b> and install a few NuGet packages.</p>
              <ul>
                <li>AutoMapper.Extensions.Microsoft.DependencyInjection</li>
                <li>FluentValidation.AspNetCore</li>
                <li>MediatR.Extensions.Microsoft.DependencyInjection</li>
              </ul>
              <p>Next we will add a folder called Articles. Inside the Articles folder we will add a new file called <b style={Violet}>List</b></p>
            </div>

            <ArticleL />
          </CardContent>
        </Card>
      </Grid.Column>
    </Grid>
  )
}