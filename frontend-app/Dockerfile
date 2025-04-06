# Use the official Node.js image as base
FROM node:18-alpine

# Set the working directory inside the container
WORKDIR /app

# Copy the package.json and package-lock.json (if available) first to leverage Docker caching
COPY package*.json ./

# Install dependencies (including react-scripts)
RUN npm install

# Copy the rest of the application code into the container
COPY . .

# Set environment variables inside Docker (API URL)
ENV REACT_APP_API_URL=http://localhost:5000/api

# Expose the port for the React app (default port 3000)
EXPOSE 3000

# Start the React application
CMD ["npm", "start"]
