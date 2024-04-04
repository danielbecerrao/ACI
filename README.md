# README.md

## .NET MVC Application

This project is a .NET MVC application designed to manage products, orders, and batches.

### Getting Started

To get started with this project, follow these steps:

1. Clone the repository to your local machine:

    ```bash
    gh repo clone danielbecerrao/ACI
    ```

2. Open the solution in Visual Studio.

3. Run the following command in the Package Manager Console to create and seed the database:

    ```bash
    update-database
    ```

### Modules

#### Products

The Products module provides CRUD (Create, Read, Update, Delete) functionality for managing products.

- **Create**: Add new products to the database.
- **Read**: View the list of existing products.
- **Update**: Modify details of existing products.
- **Delete**: Remove products from the database.

#### Orders

The Orders module allows users to create new orders.

- **Create**: Generate new orders with selected products and quantities.

#### Batches

The Batches module facilitates notifications related to batches.

- **Notifications**: Receive notifications regarding batch-related events and updates.

### Dependencies

This project utilizes the following dependencies:

- .NET Framework
- Entity Framework
- MVC Architecture

### Contributing

Contributions to this project are welcome. To contribute, please follow these guidelines:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Make your changes.
4. Commit your changes (`git commit -am 'Add some feature'`).
5. Push to the branch (`git push origin feature/your-feature`).
6. Create a new Pull Request.

### License

This project is licensed under the [MIT License](LICENSE).

### Contact

For any inquiries or support regarding this project, please contact [Your Name](mailto:daniel-3223@hotmail.com).
