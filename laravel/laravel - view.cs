# LARAVEL - VIEW

return View::first(['custom.admin', 'admin'], $data);

if (View::exists('emails.customer')) {}

# Sharing Data With All Views

class AppServiceProvider extends ServiceProvider
{
	public function boot()
    {
        View::share('key', 'value');
    }
}