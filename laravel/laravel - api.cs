# LARAVEL - API

# Request

// For convenience, the bearerToken method may be used to retrieve a bearer token from the Authorization header. 
// If no such header is present, an empty string will be returned:

$token = $request->bearerToken();

# Content Negotiation

$request->getAcceptableContentTypes();
if($request->accepts(['text/html', 'application/json'])) {}
$preferred = $request->prefers(['text/html', 'application/json']);
if ($request->expectsJson()) {}