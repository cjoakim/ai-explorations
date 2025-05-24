#!/bin/bash

az account list-locations --query "[].{Region:name}" --out table > tmp/regions.txt 

echo 'done'

