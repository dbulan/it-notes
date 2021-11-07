# LARAVEL - HTTP - REQUEST

// Request automatically trim all incoming string fields on the request, as well as convert any empty string fields to null.

public function store(Request $request)
{
	$name = $request->input('name');
}

# Request Path & Method

$uri = $request->path(); // http://example.com/foo/bar (without the query string)

$request->fullUrl();	// url with query

$request->fullUrlWithQuery(['type' => 'phone']); // append more data

// The is method allows you to verify that the incoming request path matches a given pattern.
if ($request->is('admin/*')) {} 

// Using the routeIs method, you may determine if the incoming request has matched a named route:
if ($request->routeIs('admin.*')) {}

# Request Headers

if ($request->isMethod('post'))
	
$value = $request->header('X-Header-Name');

$value = $request->header('X-Header-Name', 'default');

/** For convenience, the bearerToken method may be used to retrieve a bearer token from the Authorization header. 
If no such header is present, an empty string will be returned:
*/
$token = $request->bearerToken();

# Input

$input = $request->all();		// array
$input = $request->collect();	// collection

$request->collect('users')->each(function ($user) { // retrieve a subset
});

$name = $request->input('name');	// $request->name;
$name = $request->input('name', 'Sally');

$name = $request->input('products.0.name');
$names = $request->input('products.*.name');

$request->boolean('archived');

$input = $request->only('username', 'password');
$input = $request->except(['credit_card']);

# Determining If Input Is Present

if ($request->has(['name', 'email'])) {}
if ($request->hasAny(['name', 'email'])) {}
if ($request->filled('name')) {} // present on the request and is not empty
if ($request->missing('name')) {
	
# Old Input
/**
Laravel allows you to keep input from one request during the next request. 
This feature is particularly useful for re-populating forms after detecting validation errors. 
However, if you are using Laravel's included validation features, it is possible that you will not need to manually use these session input flashing methods directly, as some of Laravel's built-in validation facilities will call them automatically.
*/

// The flash method on the Illuminate\Http\Request class will flash the current input to the session so that it is available during the user's next request to the application:

$request->flash();
$request->flashOnly(['username', 'email']);
$request->flashExcept('password');

# Flashing Input Then Redirecting

return redirect('form')->withInput();

return redirect()->route('user.create')->withInput();

return redirect('form')->withInput(
    $request->except('password')
);

# Retrieving Old Input

$username = $request->old('username');
<input type="text" name="username" value="{{ old('username') }}">


# Cookies
// All cookies created by the Laravel framework are encrypted and signed with an authentication code, meaning they will be considered invalid if they have been changed by the client.
$value = $request->cookie('name');