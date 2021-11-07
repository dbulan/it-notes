# LARAVEL - STRIPE

# Excluding URIs From CSRF Protection
/**
Sometimes you may wish to exclude a set of URIs from CSRF protection. 
For example, if you are using Stripe to process payments and are utilizing their webhook system, you will need 
to exclude your Stripe webhook handler route from CSRF protection since Stripe will not know what CSRF token to send to your routes.
*/

namespace App\Http\Middleware;

use Illuminate\Foundation\Http\Middleware\VerifyCsrfToken as Middleware;

class VerifyCsrfToken extends Middleware
{
    protected $except = [
        'stripe/*',	// route?
        'http://example.com/foo/bar',
        'http://example.com/foo/*',
    ];
}