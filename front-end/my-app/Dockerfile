FROM node

WORKDIR /app

COPY front-end/my-app ./

RUN npm run build

COPY . .

CMD ["node", "npx serve -s build "]
