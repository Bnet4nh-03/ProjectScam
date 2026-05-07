import os
import argparse
import importlib

# Application registry
APPLICATIONS = {
    "QTIMTBAParsing": {
        "module": "src.apps.ATV_TEST_QTI_MTBA_Parsing",
        "class": "QTIMTBAParsing",
    },
    # Add other applications here
}

def main():
    parser = argparse.ArgumentParser(description="Run a specific application.")
    parser.add_argument("app_name", help=f"The name of the application to run. Available: {', '.join(APPLICATIONS.keys())}")
    parser.add_argument("--config_type", default="json", help="The type of configuration to use (e.g., json, ini).")
    args = parser.parse_args()

    app_config = APPLICATIONS.get(args.app_name)

    if not app_config:
        print(f"Error: Application '{args.app_name}' not found.")
        return

    try:
        app_module = importlib.import_module(app_config["module"])
        app_class = getattr(app_module, app_config["class"])

        config_path = os.path.join(os.path.dirname(__file__), 'config')
        app_instance = app_class(config_path, args.config_type)
        app_instance.run()

    except ImportError as e:
        print(f"Error: Could not import module '{app_config['module']}'. Details: {e}")
    except AttributeError:
        print(f"Error: Class '{app_config['class']}' not found in module '{app_config['module']}'.")
    except Exception as e:
        print(f"An error occurred: {e}")

if __name__ == '__main__':
    main()
