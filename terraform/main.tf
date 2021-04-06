terraform {
  required_providers {
    azurerm = {
      source = "hashicorp/azurerm"
      version = ">= 2.26"
    }
    aws = {
      source  = "hashicorp/aws"
      version = "~> 3.27"
    }
  }
}

provider "azurerm" {
  features {}
}

provider "aws" {
  profile = "default"
  region  = "eu-central-1"
}

resource "azurerm_resource_group" "rg" {
  name     = "myTFResourceGroup"
  location = "westeurope"

  tags = {
    Environment = "PoC Playground 1"
    Team = "DevOps Foundation"
  }
}

resource "azurerm_container_registry" "acr" {
  name                     = "asmtbookingngcontinstcontainerRegistry2"
  resource_group_name      = "myTFResourceGroup"
  location                 = "westeurope"
  sku                      = "Standard"
  admin_enabled            = true
}

output "login_server" {
  value = azurerm_container_registry.acr.login_server
}

output "admin_username" {
  value = azurerm_container_registry.acr.admin_username
}

output "admin_password" {
  value = azurerm_container_registry.acr.admin_password
}

resource "azurerm_container_group" "bookingng-cg" {
  name                = "bookingng-cg"
  location            = "westeurope"
  resource_group_name = "myTFResourceGroup"
  dns_name_label      = "bookingngprovidersservice"
  ip_address_type     = "public"
  os_type             = "Linux"

  image_registry_credential {
    server   = azurerm_container_registry.acr.login_server
    username = azurerm_container_registry.acr.admin_username
    password = azurerm_container_registry.acr.admin_password
  }

  container {
    name   = "booking-ng-providers-service"
    image  = "asmtbookingngcontinstcontainerregistry2.azurecr.io/asmt_booking-ng-providers-service:latest"
    cpu    = "0.5"
    memory = "1.5"

    ports {
      port     = 80
      protocol = "TCP"
    }
  }

  tags = {
    Environment = "PoC Playground 1"
    Team = "DevOps Foundation"
  }
}
