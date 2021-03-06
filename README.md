# El Proyecte Grande - Sprint 5

## Story

As your Codecool Journey comes closer to its conclusion, the time has come for a final Teamwork Project that will put to test all of the programming skills you've obtained so far (and some new ones you will learn on the way)!

You have the freedom of choosing your teammates (assemble a team of 3-4 students) and the project's topic this time. Think of an app that you would find useful in your daily activities, a tool that an employee of a certain industry might crave, a fun game or something completely out of the box.

This project is meant for 4 sprints at least, but it may keep you company until the end of the course, or even much longer. Who knows? Although we will not give you any direct tasks to fulfill, there will be some technical requirements for each sprint. You are expected to make incremental changes in a Scrum way, developing the project further and further, adding new features, technologies, etc.

***┬íComience El Proyecte Grande!***

## What are you going to learn?

- Work in a Scrum team on a real project.
- Grow your project iteratively.
- Deliver increments each sprint.

## Tasks

1. Create a Product backlog (on Github) with user stories that cover at least the feature set you aim to complete next. Break down the user stories into smaller tasks, prioritize them, estimate them, and taking your capacities into account, determine how far you'll be able to get during this sprint.
    - There is a Product backlog for the project.
    - The backlog items are broken down into smaller tasks or subtasks.
    - The backlog items are in priority order in the backlog.
    - Each backlog item (at least those that are relevant for the actual sprint) has an estimation value.
    - The top priority part of the backlog is marked as the Sprint backlog, in accordance with the estimation values and the foreseeable team resources.
    - The backlog and the project plan has been checked and accepted by a mentor on the first day of the sprint (before any implementation).
    - By the end of the sprint, there is less than 30% deviation from the plan (70% - 130% is completed according to the original plan)

2. You need to use technologies that help achieve agile workflow, defined below.
    - Every item in the backlog should appear as an `Issue` on GitHub.
    - The repository has a `Project` defined on GitHub for every sprint. The `project board` shall contain every issue related to the sprint.
    - With every feature branch, a `Pull request` shall be opened and maintained. The `Pull request` shall contain the `Issue` linked with it. The `Pull request` shall contain the assignee, who is responsible for the given `Issue`. The `Pull request` shall contain at least one `Reviewer`, who is responsible for checking on their peers' work.

3. You need to fulfill a couple of technical requirements defined below.
    - The project's test coverage is at least 60%.
    - The project's test coverage is at least 80%.
    - There is a workflow that runs tests upon push or PR on `development` branch.
    - There is a workflow that runs tests upon push or PR on `main` branch.
    - There is a running lint test in GitHub Actions for the app.
    - Valid Dockerfile created, the image starts the app.
    - A successful testing workflow triggers a deployment workflow (only if a PR has been merged or commits are pushed to the `main` branch).
    - The workflow builds and pushes the Docker image to DockerHub.
    - There is a Dockerfile for the database.
    - The database has no exposed ports. The application connects to the database via a docker network.
    - The workflow deploys the application's Docker image to Heroku or Netlify, the app is up and running.

4. You need to fulfill a couple of technical requirements defined below.
    - The frontend is deployed with a production build.
    - There is a `health-check` endpoint which shows the status of the backend (up or not).
    - If the backend is unavailable, the offline status is displayed on the frontend.

5. [OPTIONAL] You need to fulfill a couple of technical requirements defined below related to refreshing the page.
    - When a user is logged in, refreshing the page does not logs them out.
    - When the page is refreshed, the route (and the rendered components) stay as before refreshing.

6. [OPTIONAL] Your page should be ready to hide any malfunction - whether a missing field of the response, or a network error, it should not be displayed explicitly on the page. Use a nice error page instead, so you would not expose any weakness or vulnerability of your page, and may show a fun message instead.
    - There is a non-descriptive error page displayed for any error.
    - If the user would navigate on a non-existing route, there is a fancy `Page not found`-page displayed.

7. Implement the features and tasks from the sprint backlog.
    - By the end of the sprint, at least 50% of the sprint plan is completed (measured in estimation points)
    - By the end of the sprint, at least 60% of the sprint plan is completed (measured in estimation points)
    - By the end of the sprint, at least 70% of the sprint plan is completed (measured in estimation points)
    - By the end of the sprint, at least 80% of the sprint plan is completed (measured in estimation points)
    - By the end of the sprint, at least 90% of the sprint plan is completed (measured in estimation points)
    - By the end of the sprint, 100% of the sprint plan is completed

8. Use Scrum with your team throughout your project
    - A Daily Scrum was organized by the Scrum Master (no longer than 15 minutes).
    - Any necessary corrections in the sprint plan have been introduced to the backlog and validated by a mentor.
    - After the demo, the Scrum Master organized a Sprint Review meeting, during which the team investigates how much of the planned Sprint Backlog was fulfilled - and whether it was well thought out and balanced for the team to handle.
    - Each Sprint Review produces an Increment Document - a changelog of sorts, listing out all the changes to the product that are the result of this sprint.
    - After the Sprint Review, the Scrum Master organizes a Sprint Retrospective meeting, during which the team recalls on how the work went during this sprint, which practices were good, which should be improved, and which should be stopped (and also what to introduce).

## General requirements

None

## Hints

Our journey is coming to an end for now, *Se├▒oras y Se├▒ores*. Check if you have any optional task which you have not implemented yet from the previous sprints, and try to give them a shot.

## Background materials

- <i class="far fa-exclamation"></i> [Definition of Done](project/curriculum/materials/pages/methodology/definition-of-done.md)
- <i class="far fa-exclamation"></i> [Agile Project Management](project/curriculum/materials/pages/methodology/agile-project-management.md)
- [Quickstart on GitHub Issues](https://docs.github.com/en/issues/tracking-your-work-with-issues/quickstart)
- [Creating a pull request](https://docs.github.com/en/github/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/creating-a-pull-request)
