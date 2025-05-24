#!/bin/bash

# Capture info about your Azure Cognitive Services account usage.
#
# Chris Joakim, 2025

source ./config.sh

echo "az cognitiveservices usage list ..."
az cognitiveservices usage list \
    --location $AZURE_FOUNDRY_REGION > tmp/usage-list.json

# The following two commands are outputting empty JSON arrays. TODO - why?

echo "az cognitiveservices account deployment list ..."
az cognitiveservices account deployment list \
    --name $AZURE_FOUNDRY_NAME \
    --resource-group $AZURE_FOUNDRY_RG > tmp/acct-deployment-list.json

echo "az cognitiveservices account list-usage ..."
# TODO - this is currently outputting an empty JSON array.  Why? 
az cognitiveservices account list-usage \
    --name $AZURE_FOUNDRY_NAME \
    --resource-group $AZURE_FOUNDRY_RG > tmp/acct-list-usage.json
