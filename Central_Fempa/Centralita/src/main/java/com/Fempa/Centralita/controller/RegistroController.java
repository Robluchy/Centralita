package com.Fempa.Centralita.controller;

import com.Fempa.Centralita.model.Registro;
import com.Fempa.Centralita.model.Usuario;
import com.Fempa.Centralita.repository.RegistroRepository;
import com.Fempa.Centralita.repository.UsuarioRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/registros")
public class RegistroController {

    @Autowired
    private UsuarioRepository usuarioRepository;

    @Autowired
    private RegistroRepository registroRepository;

    @PostMapping
    public void createRegistro(@RequestBody Registro registro) {
        Usuario atendido_por = usuarioRepository.findById(registro.getAtendido_por().getId());
        Usuario empleado = usuarioRepository.findById(registro.getEmpleado().getId());
        registro.setAtendido_por(atendido_por);
        registro.setEmpleado(empleado);
        registroRepository.save(registro);
    }

    @GetMapping("/registros/{id}")
    public Registro getRegistro(@PathVariable Long id) {
        return registroRepository.findById(Math.toIntExact(id)).orElse(null);
    }

    @GetMapping
    public List<Registro> getRegistros() {
        return registroRepository.findAll();
    }

    @DeleteMapping("/registros/{id}")
    public void deleteRegistro(@PathVariable Long id) {
        registroRepository.deleteById(Math.toIntExact(id));
    }


    @PutMapping("/registros/{id}")
    public ResponseEntity<Registro> updateRegistro(@PathVariable Long id, @RequestBody Registro registro) {
        Registro registroToUpdate = registroRepository.findById(Math.toIntExact(id)).orElse(null);
        if (registroToUpdate == null) {
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }
        registroToUpdate.settelefono_persona(registro.gettelefono_persona());
        registroToUpdate.setEmail(registro.getEmail());
        registroToUpdate.setEmpresa(registro.getEmpresa());
        registroToUpdate.setFecha_hora(registro.getFecha_hora());
        registroToUpdate.setMotivo(registro.getMotivo());
        registroToUpdate.setNombre_persona(registro.getNombre_persona());
        registroToUpdate.setObservaciones(registro.getObservaciones());
        registroToUpdate.setAtendido_por(registro.getAtendido_por());
        registroToUpdate.setEmpleado(registro.getEmpleado());
        registroRepository.save(registroToUpdate);
        return new ResponseEntity<>(registroToUpdate, HttpStatus.OK);
    }


}
