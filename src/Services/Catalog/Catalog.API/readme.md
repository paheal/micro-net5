## Docker Dependency for Mongo



**To Pull Mongo image**  
docker pull mongo

**To run for project**  
 docker run -d -p 27017:27017 --name shopping-mongo mongo

**To launch interactive terminal for docker mongo db**  
docker exec -it shopping-mongo /bin/bash

---
## Once mongo interactive terminal is available
**show databases avaialble**  
show dbs

**to create a new database**  
use CatalogDB

**to create a new collection for documents**  
db.createCollection('Products')

**sample insert**  
db.Products.insertMany(  
[  
{  
"Name": "Asus Laptop",  
"Category": "Computers",  
"Summary": "Summary",  
"Description": "Description",  
"ImageFile": "ImageFile",  
"Price": 54.93  
},  
{  
"Name": "HP Laptop",  
"Category": "Computers",  
"Summary": "Summary",  
"Description": "Description",  
"ImageFile": "ImageFile",  
"Price": 88.93  
}  
]  
)

**find all records**
db.Products.find({}).pretty()

**remove records from collection** 
db.Products.remove({})

