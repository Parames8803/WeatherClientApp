# Use a lightweight web server image (Nginx) to serve the Blazor WebAssembly files
FROM nginx:alpine

# Copy the published files to the Nginx directory
COPY ./publish/wwwroot /usr/share/nginx/html

# Expose port 80 to access the application
EXPOSE 80

# Use Nginx to serve the Blazor WebAssembly app
CMD ["nginx", "-g", "daemon off;"]
