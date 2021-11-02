1. Copy nginx filename: 	C:\OpenServer\userdata\config\Nginx_1.21_vhost
2. Paste in domain folder:  C:\OpenServer\domains\www.laravel
3. Clear file and put text below:

server {
	listen                    %ip%:%httpport%;
    listen                    %ip%:%httpsport% ssl;
    server_name               %host% %aliases%;
    root                      "%hostdir%/public";
	
    add_header X-Frame-Options "SAMEORIGIN";
    add_header X-Content-Type-Options "nosniff";
	
	index index.php;
	
	charset utf-8;
	
	location / {
        try_files $uri $uri/ /index.php?$query_string;
    }
	
	location = /favicon.ico { access_log off; log_not_found off; }
    location = /robots.txt  { access_log off; log_not_found off; }
	
	error_page 404 /index.php;
	
	location ~ \.php$ {
        fastcgi_pass   backend;
        fastcgi_param SCRIPT_FILENAME $realpath_root$fastcgi_script_name;
        include        '%sprogdir%/userdata/config/nginx_fastcgi_params.txt';
    }
	
	location ~* /\.(?!well-known/) {
        deny all;
        log_not_found off;
        access_log off;
    }
}