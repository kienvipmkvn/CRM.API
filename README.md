
# CRM API Integration for Esoft
# Requirements Recap:
- Webhook for registering new potential customers.
- Viewing company products and standard prices via the PIM API.
- Registering pricing agreements for new/existing customers, creation of pricing agreements should trigger updates in PIM.
- Immediate visibility of customer conversion from Lead to Customer.

# About this project
This project demonstrates the integration of a CRM (Customer Relationship Management) system into the Esoft system landscape. 
But due to lack of condition in creating Azure service bus, I could only demonstrate the behavior of the MassTransit using the In-memory transport, and I also use InMemoryDatabase to mock the database.

## Technologies Used
- **ASP.NET Core 8**: The core framework used for building the API.
- **MassTransit**: For event-driven communication between services.
- **MediatR**: For service requests and handlers.
- **EntityFramwork Core**: For storing and retrieving data.

## System Architecture
I choose the clean achitechture for the CRM.API project. The following components are used:
- **CRM.API**: contains controllers and middlewares.
- **CRM.Application**: DTOs use for process data, MassTransit and MediatR to communicate between services. 
- **CRM.Domain**: The core object of the application.
- **CRM.Infastructure**: Implement data access logic, integration with extenal service (using HttpClient)

## Solution for the Assignment 

### 1. Registering New Customers via Webhook
The external CRM system can register new (potential) customers in Esoft's system by sending webhook notifications to the `CRM API`. The webhook payload includes customer information in JSON format, which is processed and persisted in the internal databases.

### 2. Retrieving Product and Pricing Information
The CRM system can query product and pricing information through the CRM API. The data is retrieved from the internal **PIM API**, ensuring that up-to-date pricing and product information is available to the CRM system.

### 3. Creating Pricing Agreements
As the requirement, I can assume that we can create the pricing agreement from both the CRM system and from the PIM API, so there will be 2 things I have to do here: first is receive pricing agreement from CRM system from webhook, publish it through MassTransit so the entire Esoft system can see it; and the second thing is receive the pricing agreement created from PIM through MassTransit.
Since I do not have the real PIM API, I have to create a PIM controller in the CRM API to mock the behavior of the real PIM API (publish a command when a pricing agreement is created so the CRM API can comsume that command).

### 4. Conversion from Lead to Customer
When a lead is converted to a customer in CRM system, the CRM API receive a webhook notification, then publish a LeadConvertedCommand to the Esoft internal system.

## Endpoints
You can find all the API to test this CRM.API project in the **CRM.API.http** file

## How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/kienvipmkvn/CRM.API.git
   ```

2. Navigate to the project directory:
   ```bash
   cd CRM.API
   ```

3. Restore dependencies:
   ```bash
   dotnet restore
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

The CRM API should now be running locally.

---

