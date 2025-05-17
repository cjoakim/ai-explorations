# Python AI Explorations

A collection of **exploratory** Python AI projects and tools.

# Interesting Links 

## General

- [OpenAI](https://openai.com)
- [OpenAI SDK @ PyPi](https://pypi.org/project/openai/)
- [OpenAI SDK @ GitHub](https://github.com/openai/openai-python)
- [LangChain](https://www.langchain.com/)
- [LangServe](https://python.langchain.com/docs/langserve/)
- [LangGraph](https://www.langchain.com/langgraph)
- [Ollama](https://ollama.com/)
- [LM Studio](https://lmstudio.ai)

## Azure

- [Azure OpenAI Service](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Azure OpenAI SDK Use](https://learn.microsoft.com/en-us/azure/ai-services/openai/supported-languages)
- [Azure OpenAI Models](https://learn.microsoft.com/en-us/azure/ai-services/openai/concepts/models)
- [Azure AI Foundry](https://azure.microsoft.com/en-us/products/ai-foundry)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search)
- [Azure AI Document Intelligence](https://azure.microsoft.com/en-us/products/ai-services/ai-document-intelligence)
- [PromptFlow](https://learn.microsoft.com/en-us/azure/machine-learning/prompt-flow/overview-what-is-prompt-flow)
- [Semantic Kernel](https://learn.microsoft.com/en-us/semantic-kernel/overview/)
- [Prompt engineering techniques](https://learn.microsoft.com/en-us/azure/ai-services/openai/concepts/prompt-engineering)
- [Microsoft Fabric Docs](https://learn.microsoft.com/en-us/fabric/)

---

## Azure AI Foundry

- [Azure AI Foundry Model Fine-Tuning](docs/azure_ai_foundry_model_fine_tuning.md)

### PromptFlow

- https://microsoft.github.io/promptflow/how-to-guides/quick-start.html
- https://learn.microsoft.com/en-us/azure/ai-foundry/concepts/prompt-flow
- https://pypi.org/project/promptflow/
- https://github.com/microsoft/promptflow
- https://www.youtube.com/watch?v=GD7MnIwAxYM
- https://www.youtube.com/watch?v=mnfNZmKtZ-4
- https://www.youtube.com/watch?v=DbLNRZlY9nY
- https://www.youtube.com/watch?v=M6gXchnxHik
- https://www.youtube.com/watch?v=Q0udLVx07HY
- https://www.youtube.com/watch?v=vkM_sgaMTsU
- https://www.youtube.com/watch?v=ezYR3gDiN0Q
- pip install promptflow promptflow-tools
- flow.dag.yaml file 

### Autogen 

- https://microsoft.github.io/autogen/stable/index.html
- https://devblogs.microsoft.com/autogen/microsofts-agentic-frameworks-autogen-and-semantic-kernel/
- https://devblogs.microsoft.com/autogen/

---

## Semantic Kernel

- [Semantic Kernel Overview](https://learn.microsoft.com/en-us/semantic-kernel/overview/)
- [Semantic Kernel Quick Start](https://learn.microsoft.com/en-us/semantic-kernel/get-started/quick-start-guide?pivots=programming-language-python)
- [semantic-kernel @ PyPi](https://pypi.org/project/semantic-kernel/)
- [semantic-kernel @ GitHub](https://github.com/microsoft/semantic-kernel/tree/main/python)
- [semantic-kernel Samples @ GitHub](https://github.com/microsoft/semantic-kernel/tree/main/python/samples)
- [semantic_kernel SDK Docs](https://learn.microsoft.com/en-us/python/api/semantic-kernel/semantic_kernel?view=semantic-kernel-python)

### Blogs, Books, Courses

- https://devblogs.microsoft.com
- https://devblogs.microsoft.com/semantic-kernel/
- https://devblogs.microsoft.com/semantic-kernel/recipes/
- https://devblogs.microsoft.com/cosmosdb/
- https://learn.microsoft.com/en-us/semantic-kernel/concepts/kernel/
- https://www.manning.com/books/microsoft-semantic-kernel-in-action
- https://www.udemy.com/course/understanding-semantic-kernel/
- https://www.udemy.com/course/azure-ai-agent-service-ai-foundry-semantic-kernel-sdk/

### Agents 

- https://devblogs.microsoft.com/semantic-kernel/introducing-agents-in-semantic-kernel/

### Other

- https://learn.microsoft.com/en-us/dotnet/orleans/overview

---

## MCP 

- [MCP Home](https://modelcontextprotocol.io/introduction)
- https://devblogs.microsoft.com/semantic-kernel/integrating-model-context-protocol-tools-with-semantic-kernel-a-step-by-step-guide/
- https://huggingface.co/blog/lynn-mikami/fastapi-mcp-server
- https://medium.com/@ruchi.awasthi63/integrating-mcp-servers-with-fastapi-2c6d0c9a4749
- [Hugging Face Course](https://huggingface.co/mcp-course)

---

## LangChain

### LangChain libraries for Python Virtual Environment

See the requirements.txt file in this directory, which includes:

```
$ pip list
...
ollama                   0.4.8
langchain                0.3.25
langchain-community      0.3.23
langchain-core           0.3.58
langchain-ollama         0.3.2
langchain-openai         0.3.16
langchain-text-splitters 0.3.8
langsmith                0.3.42
...
```

### LangServe

See https://python.langchain.com/docs/langserve/

> [!WARNING] We recommend using LangGraph Platform rather than LangServe for new projects.

### LangGraph

References:
- https://www.langchain.com/langgraph 
- https://langchain-ai.github.io/langgraph/

---

## Desktop AI Tools

Run LLMs/SLMs locally
 
### LM Studio

- [See lm_studio.md in this directory](docs/lm_studio.md)

### ollama

- [See ollama.md in this directory](docs/ollama.md)
- Integrates with LangChain
- https://pypi.org/project/langchain-ollama/
- https://python.langchain.com/docs/integrations/llms/ollama/
- https://python.langchain.com/api_reference/ollama/llms/langchain_ollama.llms.OllamaLLM.html
- https://medium.com/@abonia/ollama-and-langchain-run-llms-locally-900931914a46
- https://medium.com/towards-agi/how-to-use-ollama-effectively-with-langchain-tutorial-546f5dbffb70
- https://python.langchain.com/docs/integrations/providers/ollama/
- https://dev.to/emmakodes_/how-to-run-llama-31-locally-in-python-using-ollama-langchain-k8k
- 
### chromadb

- Vector search
- https://www.trychroma.com
- [See chromadb.md in this directory](docs/chromadb.md)

---

## CosmosAIGraph and AIGraph4pg 

- [CosmosAIGraph Blog](https://learn.microsoft.com/en-us/azure/cosmos-db/gen-ai/cosmos-ai-graph)
- [CosmosAIGraph Repo](https://github.com/AzureCosmosDB/CosmosAIGraph)
- [CosmosAIGraph YouTube](https://www.youtube.com/watch?v=0alvRmEgIpQ)
- [AIGraph4pg Repo](https://github.com/cjoakim/AIGraph4pg)

## Personal

- [cjoakim.github.io - JoakimSoftware](https://cjoakim.github.io)
