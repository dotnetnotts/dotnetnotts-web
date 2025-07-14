# .NET Notts Website

![Build and deploy ASP.Net Core app to Azure Web App - dotnetnotts](https://github.com/dotnetnotts/dotnetnotts-web/workflows/Build%20and%20deploy%20ASP.Net%20Core%20app%20to%20Azure%20Web%20App%20-%20dotnetnotts/badge.svg)

The new .NET Notts website written in Blazor. You can find the site at it's temporary domain name here;

https://dotnetnotts.azurewebsites.net/

# Contents

- [Contributing](#contributing)
- [Local Development](#local-development)
    - [Building Locally](#building-locally)
    - [Running Locally](#running-locally)
    - [Running Tests](#running-tests)
- [Build Tool](#build-tool)
- [Branding](#branding)

<br/>

# Contributing

Before contributing to this repository please follow the following steps. Also please check [the contribution guidelines.](.github/contributing.md)

<br/>

## Step 1 - Check for any issue

Before making any changes, check to see if there are any issues describing the feature you want to add or the bug you want to fix.


### If there isn't an issue for the change you want to make, raise one

In the case that an issue doesn't exist for the change you want to make, raise one and fill in all the details asked for in the template.

<br/>

## Step 2 - Comment on the issue you want to pick up

When you have found an issue, comment on it requesting that you want to pick up the issue. If you have raised the issue, you can comment straight away saying you are going to resolve the issue yourself.

The reason for this is we have many people wanting to make certain changes, and we are running a first-come rota on who gets the issue. The first person to ask on an issue gets to resolve it.

<br/>

## Step 3 - One of the owners will comment and set to `in-progress`

If you can pick up an issue, the owners of the repository will comment saying so and set a `in-progress` label on the issue.

<br/>

## Extra Notes
---

## First come first served

We are managing the demand to contribute by allowing the first person to request addressing a change on an issue to be the person whose PR we will review.

Some issues can have multiple contributions, so please do ask on the issue if you can still contribute.

<br/>

## Please only pick up one issue at a time, and a maximum of two issues over October

There are many small changes available in the issues. This is to ensure there are plenty of issues available for different first time contributors to pick up.

Please don't address more than two issues in this repository. 

<br/>

## Please be patient

The maintainers look after this repository in their free time outside of full time jobs. They also have other priorities and commitments. We will try to address issues and pull requests in a timely manner, but sometimes it will take a few days. Please be patient.

<br/>

# Local Development 

## Building Locally

To build the project use the command `dotnet build` in the terminal of your choice.

## Running Locally

To run the project locally use the command `dotnet run` in the terminal of your choice. This make the site available on `http://localhost:5000/`. Access that address in the browser of your choice to see your local version of the website.

## Running Tests

To run tests use the command `dotnet test` in the terminal of your choice.
If you wish to test code coverage, you can also run `dotnet test --collect:"XPlat Code Coverage"`.

Existing test suites can be found under the `./tests` folder. As of writing, the tests consist of only unit-level / component-level tests written using [bUnit](https://github.com/egil/bUnit).

If you are editing or adding new components, please consider adding or updating tests to reflect your changes!

<br/>

# Build Tool

GitHub Actions is set up to build and run tests from Pull Requests so that we can ensure the project builds and tests pass from any changes made within branches before they are merged in. 

GitHub Actions is also used to deploy on merge into master.

![Build and deploy ASP.Net Core app to Azure Web App - dotnetnotts](https://github.com/dotnetnotts/dotnetnotts-web/workflows/Build%20and%20deploy%20ASP.Net%20Core%20app%20to%20Azure%20Web%20App%20-%20dotnetnotts/badge.svg)


<br/>

# Branding

We ask that you make your changes to the front end with the following branding guidelines in mind:

![.NET Notts Branding](https://res.cloudinary.com/dsfcrod4r/image/upload/v1598552467/branding_ydno1a.png)

## Accessible Color Palette

The .NET Notts website uses an accessible color palette that meets WCAG AA contrast requirements while maintaining brand identity. All colors are available as CSS custom properties for consistent usage.

### Primary Colors (Teal Theme)
- **Primary**: `#007A6B` (`--color-primary`) - Main brand color, contrast ratio ~4.6:1
- **Primary Light**: `#00A693` (`--color-primary-light`) - For hover states and highlights
- **Primary Dark**: `#005A4F` (`--color-primary-dark`) - For pressed states and borders

### Secondary Colors (Blue for Links)
- **Secondary**: `#2B6CB0` (`--color-secondary`) - Links and secondary actions, contrast ratio ~4.8:1
- **Secondary Light**: `#4299E1` (`--color-secondary-light`) - For hover states
- **Secondary Dark**: `#1A365D` (`--color-secondary-dark`) - For pressed states

### Text Colors
- **Primary Text**: `#1A202C` (`--color-text-primary`) - Main text color, contrast ratio ~12.6:1
- **Secondary Text**: `#4A5568` (`--color-text-secondary`) - Subdued text
- **Light Text**: `#FFFFFF` (`--color-text-light`) - Text on dark backgrounds

### Background Colors
- **Background**: `#FFFFFF` (`--color-background`) - Main background
- **Background Alt**: `#F7FAFC` (`--color-background-alt`) - Secondary background

### Status Colors
- **Success**: `#38A169` (`--color-success`) - Success states
- **Warning**: `#D69E2E` (`--color-warning`) - Warning states
- **Error**: `#E53E3E` (`--color-error`) - Error states
- **Info**: `#3182CE` (`--color-info`) - Information states

## Usage Guidelines

### CSS Custom Properties
Use the CSS custom properties (variables) instead of hardcoded hex values:

```css
/* Good */
.my-component {
    background-color: var(--color-primary);
    color: var(--color-text-light);
}

/* Avoid */
.my-component {
    background-color: #007A6B;
    color: #FFFFFF;
}
```

### Accessibility Considerations
- All color combinations meet WCAG AA contrast ratios (4.5:1 for normal text, 3:1 for large text)
- Blue links provide better accessibility for users with color vision deficiencies
- High contrast mode support is included for users with contrast preferences
- Focus states are clearly visible with proper contrast ratios

### Font
Font: Open Sans (fallback to sans-serif)

<br/>

