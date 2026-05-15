class ModuleBase:
    """Base class for pluggable app modules (tabs).

    Subclasses should implement `build(self, parent)` to create UI
    under the given parent frame and `run_module(file_path, table_name, key_columns)`
    to perform actions when the app triggers a run.
    """
    def __init__(self, app):
        self.app = app

    def build(self, parent):
        raise NotImplementedError

    def run_module(self, file_path, table_name, key_columns):
        raise NotImplementedError

    def name(self):
        return self.__class__.__name__
