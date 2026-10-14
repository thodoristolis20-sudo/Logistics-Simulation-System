# 🚚 Logistics Simulation System

**A logistics and fleet management simulation built with C# and .NET.**

A software engineering project that simulates the operations of a logistics company, focusing on truck fleet management, order scheduling, transportation costs, revenue, and profit optimization.

The system uses discrete-time simulation to model logistics operations over a simulated six-month period and compare different order-scheduling strategies.

## 📖 About the Project

The Logistics Simulation System models a transportation company operating across multiple cities connected by a road network.

Customers generate orders that must be assigned to available trucks. The simulation tracks transportation distances, truck capacities, operating costs, revenue, and overall profitability.

The primary goal is to compare alternative scheduling strategies and investigate how more efficient truck utilization can improve business performance.

## ✨ Features

* 🚛 **Fleet Management** — Manage trucks with different transportation capacities and starting locations.
* 🏙️ **Road Network Simulation** — Represent cities and distances using a graph-based model.
* 📦 **Order Management** — Generate and process short-term and long-term customer orders.
* 👥 **Customer Simulation** — Support industrial and merchant customers distributed across different cities.
* 🧠 **Scheduling Strategies** — Implement interchangeable order-assignment policies.
* 📊 **Performance Metrics** — Track total distance, transportation costs, revenue, and profit.
* ⏱️ **Discrete-Time Simulation** — Simulate logistics operations over a six-month period.
* 🔄 **Multiple Simulation Runs** — Compare results across different runs and scheduling strategies.

## 🧠 Scheduling Strategies

The system implements two different scheduling policies.

### 1. Base Scheduling Policy

Assigns orders to the first available truck without grouping orders together.

### 2. Alternative Scheduling Policy

Groups orders by destination city and attempts to improve truck capacity utilization while reducing the number of trips.

The two strategies can be compared to evaluate their impact on transportation costs and overall profitability.

## 🏗️ Architecture

The project follows a **Layered Architecture**, separating the main responsibilities of the simulation.

| Component           | Responsibility                                                    |
| ------------------- | ----------------------------------------------------------------- |
| `SimulationEngine`  | Controls the main simulation loop and coordinates system updates. |
| `SimulationClock`   | Manages simulated time in days and hours.                         |
| `City`              | Represents a city in the simulated road network.                  |
| `RoadGraph`         | Represents cities and distances between them.                     |
| `Customer`          | Represents customers who generate orders.                         |
| `Order`             | Stores order information, volume, type, and completion status.    |
| `Truck`             | Manages truck capacity, location, and availability.               |
| `Warehouse`         | Represents warehouses with storage capacity.                      |
| `ISchedulingPolicy` | Defines the interface for order-scheduling strategies.            |
| `MetricsCollector`  | Collects simulation performance metrics.                          |

## 🛠️ Technologies

* **Language:** C#
* **Platform:** .NET
* **Development Environment:** Visual Studio Code
* **Application Type:** Console Application
* **Version Control:** Git and GitHub

The implementation uses standard .NET libraries without external frameworks.

## 📊 Performance Metrics

The simulation collects metrics to evaluate the performance of each scheduling strategy.

* Total distance travelled by the truck fleet
* Total transportation cost
* Total volume of transported goods
* Total revenue
* Overall profit

**Profit = Total Revenue − Total Transportation Cost**

These metrics provide a basis for comparing scheduling policies and evaluating resource utilization.

## 📈 Results

The project report indicates that the Alternative Scheduling Policy achieved higher overall profit than the Base Scheduling Policy.

This improvement was primarily attributed to better truck capacity utilization and fewer required trips, resulting in lower transportation costs.

Because the simulation includes randomized elements, numerical results may vary between runs.

## 🚀 Getting Started

### Prerequisites

* A compatible .NET SDK
* Visual Studio Code or another C# development environment
* Git (optional, for cloning the repository)

### Installation

Clone the repository:

```bash
git clone https://github.com/ThodorisTolis/logistics-simulation.git
```

Navigate to the project directory:

```bash
cd logistics-simulation
```

Open the project in your preferred C# development environment.

### Running the Simulation

If the repository contains a `.csproj` file, run the application using:

```bash
dotnet run
```

If the project contains a solution file or multiple projects, select the appropriate startup project before running it.

## 🎯 Project Objectives

* Model a logistics company's operations using simulation.
* Evaluate truck fleet utilization and transportation costs.
* Implement interchangeable scheduling policies.
* Compare alternative operational strategies.
* Investigate how scheduling decisions affect profitability.
* Apply software engineering principles to a practical problem.

## 📚 Academic Context

Developed as part of the **Software Engineering (SW Engineering — Simulation)** course for the BSc (Hons) in Computing program at Aegean College.

## 👨‍💻 Author

**Thodoris Tolis**

GitHub: [@ThodorisTolis](https://github.com/ThodorisTolis)

## 📄 License

No open-source license has been specified. Unless a license is added, the source code remains subject to applicable copyright law.

---

<p align="center">
  <b>Logistics Simulation System</b><br>
  Simulating logistics. Comparing strategies. Optimizing profit.
</p>
