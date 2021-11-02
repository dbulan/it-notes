# --- TODO
Laravel Sanctum // Laravel Sanctum provides a featherweight authentication system for SPAs (single page applications), mobile applications, and simple, token based APIs
Single-page application hybrid technology like Inertia.js + Laravel
Laravel may also serve as an API backend to a JavaScript single-page application or mobile application.
For example, you might use Laravel as an API backend for your Next.js application

PSR4 https://www.php-fig.org/psr/psr-4/

# Laravel AUTH

(!) For those brand new to Laravel, we recommend learning the ropes with Laravel Breeze before graduating to Laravel Jetstream.

Laravel Breeze    | Laravel Breeze is a minimal, simple implementation of all of Laravel's authentication features, including login, registration, password reset, email verification, and password confirmation. 
Laravel Jetstream | Jetstream provides a beautifully designed application scaffolding for Laravel and includes login, registration, email verification, two-factor authentication, session management, API support via Laravel Sanctum, and optional team management.

# Install Breeze

$ composer create-project laravel/laravel . // install app
$ php artisan migrate	// run your database migrations
$ composer require laravel/breeze --dev
$ php artisan breeze:install
$ npm install
$ npm run dev
$ php artisan migrate

// Next, you may navigate to your application's /login or /register URLs in your web browser. All of Breeze's routes are defined within the routes/auth.php file.

# Install Breeze and Inertia
// Laravel Breeze also offers an Inertia.js frontend implementation powered by Vue or React. 
// To use an Inertia stack, specify vue or react as your desired stack when executing the breeze:install Artisan command:
$ php artisan breeze:install vue
$ npm install
$ npm run dev
$ php artisan migrate

# ----- Laravel

When referencing the Laravel framework or its components from your application or package, 
you should always use a version constraint such as ^8.0, since major releases of Laravel do include breaking changes.

The new minimum PHP version is now 7.3.0

# Installation Via Composer

$ composer create-project laravel/laravel .

# Single-page application hybrid technology like Inertia.js + Laravel

# Laravel The API Backend
Laravel may also serve as an API backend to a JavaScript single-page application or mobile application.
For example, you might use Laravel as an API backend for your Next.js application. 
In this context, you may use Laravel to provide authentication and data storage / retrieval for your application,
while also taking advantage of Laravel's powerful services such as queues, emails, notifications, and more.

# Configuration Caching

To give your application a speed boost, you should cache all of your configuration files into a single file using the config:cache Artisan command. 
This will combine all of the configuration options for your application into a single file which can be quickly loaded by the framework.

You should typically run the php artisan config:cache command as part of your production deployment process. 
The command should not be run during local development as configuration options will frequently need to be changed during the course of your application's development.

If you execute the config:cache command during your deployment process, you should be sure that you are only calling the env function from within your configuration files. 
Once the configuration has been cached, the .env file will not be loaded; therefore, the env function will only return external, system level environment variables.

# Debug
The debug option in your config/app.php configuration file determines how much information about an error is actually displayed to the user. 
By default, this option is set to respect the value of the APP_DEBUG environment variable, which is stored in your .env file.

# Maintenance Mode

$ php artisan down
$ php artisan down --refresh=15 // refresh every 15 seconds
$ php artisan down --retry=60	// ???
$ php artisan down --redirect=/
$ php artisan up

$ php artisan down --secret="1630542a-246b-4b66-afa1-dd72a4c43515"

/*
	https://example.com/1630542a-246b-4b66-afa1-dd72a4c43515 
	Once the cookie has been issued to your browser, you will be able to browse the application normally as if it was not in maintenance mode. 
*/

$ php artisan down --render="errors::503"
/*
	(!) If you utilize the php artisan down command during [Deployment], your users may still occasionally encounter errors.
	
	For this reason, Laravel allows you to pre-render a maintenance mode view
	This view is rendered before any of your application's dependencies have loaded. 
*/

// You may customize the default maintenance mode template by defining your own template at: resources/views/errors/503.blade.php
// ! While your application is in maintenance mode, no queued jobs will be handled.

# ::::::: Deploy / Cache
$ php artisan down // with params
$ php artisan config:cache
~ set: APP_DEBUG=false

$ php artisan up

# :::::::  Configure App
$ php artisan storage:link // symbolic link for user uploads

# Server Requirements

PHP >= 7.3 | BCMath PHP Extension | Ctype PHP Extension | Fileinfo PHP Extension | JSON PHP Extension | Mbstring PHP Extension | OpenSSL PHP Extension | PDO PHP Extension | Tokenizer PHP Extension | XML PHP Extension


# The Routes Directory
The web.php places in the web middleware group. Which provides session state, CSRF protection, and cookie encryption.
The api.php places in the api middleware group. These routes are intended to be stateless, requests intended to be authenticated [Laravel Sanctum] via tokens and will not have access to session state.

# The Storage Directory

The storage/app/public directory may be used to store user-generated files, such as profile avatars, that should be publicly accessible. 
You should create a symbolic link at public/storage which points to this directory. 
You may create the link using the php artisan storage:link Artisan command.

# The Tests Directory
$ php vendor/bin/phpunit // simple
$ php artisan test		 // more detailed

# ----- Composer

$ composer self-update // update