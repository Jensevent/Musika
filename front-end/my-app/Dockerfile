FROM node:17-alpine

WORKDIR /app

COPY front-end/my-app ./

RUN npm install

RUN npm run build

COPY . .

#CMD ["npm", "start"]

CMD ["npx", "serve", "-s", "build"]
#MD ["serve", "-s", "build"]