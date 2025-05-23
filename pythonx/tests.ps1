# This script executes the complete set of unit tests,
# with code coverage reporting.
# Chris Joakim, 2025

New-Item -ItemType Directory -Force -Path .\tmp | out-null
del tmp/*.*

echo 'executing unit tests with code coverage ...'
pytest -v --cov=src/ --cov-report html tests/
