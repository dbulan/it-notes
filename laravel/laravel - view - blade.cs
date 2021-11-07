# LARAVEL - VIEW - BLADE

// In fact, all Blade templates are compiled into plain PHP code and cached until they are modified, meaning Blade adds essentially zero overhead to your application.

// Blade's {{ }} echo statements are automatically sent through PHP's htmlspecialchars function to prevent XSS attacks.

# Rendering JSON

<script>
    var app = @json($array); // JSON_HEX_TAG, JSON_HEX_APOS, JSON_HEX_AMP, and JSON_HEX_QUOT

    var app = @json($array, JSON_PRETTY_PRINT);
</script>

# Displaying Unescaped Data

Hello, {!! $name !!}.

# Blade & JavaScript Frameworks

// Since many JavaScript frameworks also use "curly" braces to indicate a given expression 
// should be displayed in the browser, you may use the @ symbol to inform the Blade rendering engine an expression should remain untouched.

Hello, @{{ name }}.

# The @verbatim Directive

// If you are displaying JavaScript variables in a large portion of your template, you may wrap the HTML 
// in the @verbatim directive so that you do not have to prefix each Blade echo statement with an @ symbol

@verbatim
    <div class="container">
        Hello, {{ name }}.
    </div>
@endverbatim


# If Statements

@isset($records)
    // $records is defined and is not null...
@endisset

@empty($records)
    // $records is "empty"...
@endempty

# Authentication Directives

@auth
    // The user is authenticated...
@endauth

@guest
    // The user is not authenticated...
@endguest

# Is Admin

@auth('admin')
    // The user is authenticated...
@endauth

@guest('admin')
    // The user is not authenticated...
@endguest

# Environment Directives

@production
    // Production specific content...
@endproduction

@env('staging')
    // The application is running in "staging"...
@endenv

@env(['staging', 'production'])
    // The application is running in "staging" or "production"...
@endenv

# Loops

@forelse ($users as $user)
    <li>{{ $user->name }}</li>
@empty
    <p>No users</p>
@endforelse
	
//

@foreach ($users as $user)
    @foreach ($user->posts as $post)
        @if ($loop->parent->first)
            This is the first iteration of the parent loop.
        @endif
    @endforeach
@endforeach

# $loop

$loop->index, $loop->iteration, $loop->remaining, $loop->count, $loop->first, $loop->last, $loop->even, $loop->odd, $loop->depth, $loop->parent

# Conditional Classes

@php
    $isActive = false;
    $hasError = true;
@endphp

<span @class([
    'p-4',
    'font-bold' => $isActive,
    'text-gray-500' => ! $isActive,
    'bg-red' => $hasError,
])></span>

# Including Subviews

@include('shared.errors')
@include('view.name', ['status' => 'complete'])

@includeWhen($boolean, 'view.name', ['status' => 'complete'])

@includeUnless($boolean, 'view.name', ['status' => 'complete'])

# each

@each('view.name', $jobs, 'job')

# The @once Directive

// The @once directive allows you to define a portion of the template that will only be evaluated once per rendering cycle. 
// This may be useful for pushing a given piece of JavaScript into the page's header using stacks. 
// For example, if you are rendering a given component within a loop, you may wish to only push the JavaScript to the header the first time the component is rendered:

@once
    @push('scripts')
        <script>
            // Your custom JavaScript...
        </script>
    @endpush
@endonce

# Components

$ php artisan make:component Alert
$ php artisan make:component Forms/Input

# Extending A Layout

@extends('layouts.app')

@section('title', 'Page Title')

@section('sidebar')
    @parent

    <p>This is appended to the master sidebar.</p>
@endsection

@section('content')
    <p>This is my body content.</p>
@endsection

# Validation Errors

<label for="title">Post Title</label>

<input id="title" type="text" class="@error('title') is-invalid @enderror">

@error('title')
    <div class="alert alert-danger">{{ $message }}</div>
@enderror

//

<label for="email">Email address</label>

<input id="email" type="email" class="@error('email') is-invalid @else is-valid @enderror">

//

<label for="email">Email address</label>

<input id="email" type="email" class="@error('email', 'login') is-invalid @enderror">

@error('email', 'login')
    <div class="alert alert-danger">{{ $message }}</div>
@enderror

# Stacks

// Blade allows you to push to named stacks which can be rendered somewhere else in another view or layout. 
// This can be particularly useful for specifying any JavaScript libraries required by your child views:

@push('scripts')
    <script src="/example.js"></script>
@endpush

<head>
    <!-- Head Contents -->

    @stack('scripts')
</head>

//

@push('scripts')
    This will be second...
@endpush

// If you would like to prepend content onto the beginning of a stack, you should use the @prepend directive:

@prepend('scripts')
    This will be first...
@endprepend

# Service Injection

@inject('metrics', 'App\Services\MetricsService')

<div>
    Monthly Revenue: {{ $metrics->monthlyRevenue() }}.
</div>