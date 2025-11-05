provider "azurerm" {
  features {}
  subscription_id = "18a54fef-d36d-4d1c-b7b4-c468a773149b"
}

data "azurerm_resource_group" "existing" {
  name = "rg-group1-sch"
}

resource "azurerm_app_service_plan" "plan" {
  name                = "photoapi-plan"
  location            = data.azurerm_resource_group.existing.location
  resource_group_name = data.azurerm_resource_group.existing.name

  sku {
    tier = "Basic"
    size = "B1"
  }

  kind     = "Linux"
  reserved = true
}

resource "azurerm_app_service" "app" {
  name                = "photoapi-app"
  location            = data.azurerm_resource_group.existing.location
  resource_group_name = data.azurerm_resource_group.existing.name
  app_service_plan_id = azurerm_app_service_plan.plan.id

  site_config {
    linux_fx_version = "DOTNET|9.0"
  }

  app_settings = {
    "WEBSITE_RUN_FROM_PACKAGE" = "1"
  }
}
